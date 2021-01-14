import { Button, Card, CardContent, createStyles, TextField, withStyles } from '@material-ui/core';
import * as React from 'react';
import { Component } from 'react';

export interface EditJobProps {
    classes: any;
    nume: string;
    descriere: string;
    handleData:any;
    buttonFunction:any;
    buttonName:any;
}
 
export interface EditJobState {
    
}

const styles = createStyles({
    textFieldBox: {
        display: 'flex',
        flexDirection: 'column',
        width:'90%',
        margin: 'auto',
        marginTop: '4%',
        marginBottom: '4%',
    },
    numeBox: {
        width:'100%',
        marginBottom:'4%',
    },
    descriereBox: {
        width:'100%'
    },
    nume: {
        width: '100%',
    },
    descriere: {
        width: '100%',
    },
    nextButtonBox : {
        width: '100%',
        marginBottom: '4%',
    },
    nextButton : {
        float: 'right',
        marginRight:'8%',
        padding: '11px',
    }
});
 
class EditJob extends React.Component<EditJobProps, EditJobState> {
    
    handleData = (type: any) => (event: any) => {
        this.props.handleData({
            [type]: event.target.value,
        });
    };

    render() {
        const {classes, nume, descriere} = this.props;
        return (
            <div>
                <div className = {classes.textFieldBox}>
                    <div className={classes.numeBox}>
                        <Card>
                            <CardContent>
                                <TextField
                                label = "Nume" 
                                variant = "outlined" 
                                value = {nume} 
                                onChange={this.handleData('nume')}
                                className = {classes.nume}
                                />
                            </CardContent>
                        </Card>
                    </div>
                    <div className={classes.descriereBox}>
                        <Card>
                            <CardContent>
                                <TextField
                                label = "Descriere"
                                variant = "outlined"
                                value = {descriere}
                                onChange={this.handleData('descriere')}
                                multiline
                                rows = {20}
                                className = {classes.descriere} 
                                />
                            </CardContent>
                        </Card>
                    </div>
                </div>
                <div className = {classes.nextButtonBox}>
                    <Button variant="contained" color="primary" className = {classes.nextButton} onClick={this.props.buttonFunction}>
                       {this.props.buttonName}
                    </Button>
                </div>
            </div>
        );
    }
}
 
export default withStyles(styles)(EditJob);