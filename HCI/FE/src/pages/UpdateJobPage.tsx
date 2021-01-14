import * as React from 'react';
import { Component } from 'react';
import UpdateJob from '../components/UpdateJob';

export interface UpdateJobPageProps {
    
}
 
export interface UpdateJobPageState {
    jobList: any;
}
 
class UpdateJobPage extends React.Component<UpdateJobPageProps, UpdateJobPageState> {
    
    constructor(props: UpdateJobPageProps) {
        super(props);

        this.state = {
            jobList: [
                {
                    nume: "Pescar",
                    descriere: "Trebuie sa prindeti pesti"
                },
                {
                    nume: "Bombardier",
                    descriere: "Trebuie sa bombardati"
                },
                {
                    nume: "Malaxor",
                    descriere: "Trebuie sa malaxezi"
                },
                {
                    nume: "Cocostarc",
                    descriere: "Trebuie sa cocorstacesti"
                },
                {
                    nume: "Lorem",
                    descriere: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
            ]
        }
    }

    render() { 
        return (
            <div>
                <UpdateJob
                {...this.state}
                />
            </div>
        );
    }
}
 
export default UpdateJobPage;