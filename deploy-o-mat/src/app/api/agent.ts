import axios, { AxiosResponse } from 'axios';
import { IDockerImage } from '../models/dockerImage';
import { IDockerService } from '../models/dockerService';
import { IUser, IUserFormValues } from '../models/user';
import { toast } from 'react-toastify';
import { history } from '../..';
import { IDockerStackLog } from '../models/dockerStackLog';

axios.defaults.baseURL = process.env.REACT_APP_API_URL!;// 'http://localhost:5000/api';
const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use((config) => {
    const token = window.localStorage.getItem('jwt');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
}, error => {
    return Promise.reject(error);
});

axios.interceptors.response.use(undefined, error => {
    if (error.message === 'Network Error' && !error.response) {
        toast.error('Network error - make sure API is running!');
    }
    const { status, data, config } = error.response;
    if (status === 404) {
        history.push('/notfound')
    }
    if (status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id')) {
        history.push('/notfound');
    }
    if (status === 500) {
        toast.error('Server error - check the terminal for more info!');
    }
    throw error.response;
});

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
}

const DockerImages = {
    list: (): Promise<IDockerImage[]> => requests.get("/dockerimage"),
    details: (id: string) => requests.get(`/dockerimage/${id}`),
    restart: (id: string) => requests.post(`/dockerimage/restart`, { id })
}

const DockerServices = {
    list: (): Promise<IDockerService[]> => requests.get("/dockerservice"),
}

const DockerInfo = {
    stackLogs: (): Promise<IDockerStackLog[]> => requests.get("/dockerinfo/stackLogs")

}

const User = {
    current: (): Promise<IUser> => requests.get('/user'),
    login: (user: IUserFormValues): Promise<IUser> => requests.post(`/user/login`, user),
    register: (user: IUserFormValues): Promise<IUser> => requests.post(`/user/register`, user)
}

export default { DockerImages, DockerServices, User, DockerInfo }