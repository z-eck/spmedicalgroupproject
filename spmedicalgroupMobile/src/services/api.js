import axios from 'axios';

const api = axios.create({
    baseURL: 'http://192.168.4.100:5000/api'
})

export default api;