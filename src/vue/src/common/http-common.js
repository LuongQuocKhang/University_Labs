import axios from 'axios';

export const http = axios.create({
	baseURL: import.meta.env.VITE_API_URL,
	headers: {
		Authorization: 'Bearer {token}',
		'Access-Control-Allow-Origin': '*',
		'Content-Type': 'application/json'
	},
	withCredentials: true,
	auth: {
		username: 'luong.quockhang@amaris.com',
		password: 'g%3XPr@4'
	}
})