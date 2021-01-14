import axios, { AxiosInstance } from 'axios';

class ServiceApi {
    private instance: AxiosInstance;
    constructor() {
    	this.instance = axios.create({
            baseURL:'http://localhost:3000',
    	});

    }

    async getJobs() {
    	return this.instance.get('/admin/jobs');
    }

    async getCv(id:any) {
    	return this.instance.get('http://localhost:3000/admin/cvs/forjob/'+id);
    }

    async getCvById(id:any) {
    	return this.instance.get('http://localhost:3000/admin/cvs/'+id);
    }

    async updateCv(body:any, id:any) {
    	return this.instance.put('http://localhost:3000/admin/cvs/'+id,body);
    }

    async getXcel(body:any) {
    	return this.instance.post('http://localhost:3000/admin/jobs/excel',body);
    }

    async getJobById(id:any) {
    	return this.instance.get('http://localhost:3000/admin/jobs/'+id);
    }

    async deleteJob(id:any) {
    	return this.instance.delete('http://localhost:3000/admin/jobs/'+id);
    }

    async deleteCV(id:any) {
    	return this.instance.delete('http://localhost:3000/admin/cvs/'+id);
    }

    async saveJob(body:any) {
    	return this.instance.post('http://localhost:3000/admin/jobs/add',body);
    }

    async saveCv(body:any) {
    	return this.instance.post('http://localhost:3000/admin/cvs/add',body);
    }

    async updateJob(body:any , id:any) {
    	return this.instance.put('http://localhost:3000/admin/jobs/'+id,body);
    }

    async login(body:any) {
    	return this.instance.post('http://localhost:3000/loginData/',body);
    }
}
export default ServiceApi;