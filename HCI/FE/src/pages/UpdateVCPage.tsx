import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import UpdateCV from '../components/UpdateCV';
import ServiceApi from '../remote/ServiceApi'
export interface UpdateCVPageProps  extends RouteComponentProps{
}
 
export interface UpdateCVPageState {
    imgSrc:string;
    varsta:string;
    gen:string;
    casatorit:string;
    educatie:string;
    munca:string;
    nume:string;
    buttonText:any;
    buttonFunction:any;
}
 
class UpdateCVPage extends React.Component<UpdateCVPageProps, UpdateCVPageState> {
    private service:ServiceApi = new ServiceApi();
    constructor(props:UpdateCVPageProps) {
        super(props);
        this.state = {
            imgSrc:'',
            varsta:'',
            gen:'',
            casatorit:'',
            educatie:'',
            munca:'',
            nume:'',
            buttonText:"next",
            buttonFunction:'',
        }
    }

    async  componentDidMount(){
        const id = localStorage.getItem('idCV');
        console.log(id);
        if(id=== "-1" || id == undefined )
        {
            this.setState({
                imgSrc:"",
                varsta:"",
                educatie:"",
                munca:"",
                nume:"",
                buttonText:"Save",
                buttonFunction:this.save
            })
            return;
        }
        let job;
        try{
            job =await this.service.getCvById(id);
            job=job.data;
        }catch(err)
        {
            console.log(err)
        }
        console.log(job);
        this.setState({
            imgSrc:job.photo_id,
            varsta:job.age,
            gen:job.sex,
            educatie:job.education,
            munca:job.professional,
            nume:job.name,
            buttonText:"Update",
            buttonFunction:this.update
        })
    }


    save = async (imgg:any)=>{
        try{
            const idjob = localStorage.getItem('job');
            const data = {
                img:imgg,
                age:this.state.varsta,
                education:this.state.educatie,
                name:"dragos",
                professional:this.state.educatie,
                sex:this.state.gen,
                job_id:idjob,
            }
            await this.service.saveCv(data);
        }catch(err)
        {
            console.log(err);
        }
        this.props.history.push("/home");
        
    }

    update =async (imgg:any)=>{
        const id = localStorage.getItem('idCV');
        try{
            const data = {
                img:imgg,
                age:this.state.varsta,
                education:this.state.educatie,
                name:this.state.nume,
                professional:this.state.educatie,
                sex:this.state.gen
            }
            await this.service.updateCv(data,id)
        }catch(err)
        {
            console.log(err);
        }
        this.props.history.push("/home");
    }

    toBase64 = (file:any) => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });

    handleChange = (data: any) => {
        this.setState({
            ...data,
        });
    };

    render() { 
        return (
            <div>
                <UpdateCV 
                {...this.state}
                handleChange={this.handleChange}
                />
            </div>
        );
    }
}
 
export default UpdateCVPage;