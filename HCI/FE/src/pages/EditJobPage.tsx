import * as React from 'react';
import { Component } from 'react';
import { RouteComponentProps } from 'react-router-dom';
import EditJob from '../components/EditJob';
import ServiceApi from '../remote/ServiceApi'
export interface UpdateJobPageProps extends RouteComponentProps{
    
}
 
export interface UpdateJobPageState {
    nume: string;
    descriere: string;
    buttonFunction:any;
    buttonName:any;
}
 
class UpdateJobPage extends React.Component<UpdateJobPageProps, UpdateJobPageState> {
    private service:ServiceApi = new ServiceApi();

    async componentDidMount(){
        const id = localStorage.getItem('idJob');
        if(id=== "-1" || id == undefined)
        {
            this.setState({
                nume:'',
                descriere:'',
                buttonFunction:this.save,
                buttonName:"Save"
            })
            return;
        }
        try{
            const job = await this.service.getJobById(id);
            this.setState({
                nume:job.data.name,
                descriere:job.data.description,
                buttonFunction:this.update,
                buttonName:"Back"

            })
            console.log(job);
        }catch(err)
        {

        }
    }


    save = async ()=>{
         try{
             await this.service.saveJob({
                 name:this.state.nume,
                 description:this.state.descriere
             })
             this.props.history.push("/home");
        }catch(err){
            console.log(err)
        }
    }

    update= () => {
        this.props.history.push("/home");
    }

    handleChange = (data: any) => {
        this.setState({
            ...data,
        });
    }

    render() { 
        return (
            <div>
                <EditJob
                {...this.state}
                handleData={this.handleChange}
                />
            </div>
        );
    }
}
 
export default UpdateJobPage;