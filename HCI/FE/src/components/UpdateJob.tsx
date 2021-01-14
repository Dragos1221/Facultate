import { Button, Card, CardContent, createStyles, Typography, withStyles } from '@material-ui/core';
import * as React from 'react';
import { Component } from 'react';
import BorderColorIcon from '@material-ui/icons/BorderColor';

export interface UpdateJobProps {
    classes: any;
    jobList: any;
}
 
export interface UpdateJobState {
    
}

const styles = createStyles({
    cardTitle : {
        marginBottom:'20px'
    },
    cardBox : {
        width: '85%'
    },
    buttonBox : {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        width : '15%'
    },
    buttonBox2 : {
    },
    jobsBox : {
        display: 'flex',
        flexDirection: 'column',
        marginTop: '4%',
    },
    oneJobBox : {
        display: 'flex',
        flexDirection: 'row',
        width: '90%',
        margin: 'auto',
        marginBottom: '4%',
    },
    button : {
        display: 'inline-flex',
    },
    editIcon : {
        marginRight: '25%'
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
})
 
class UpdateJob extends React.Component<UpdateJobProps, UpdateJobState> {

    makeItem = (elem: any) => {
        const {classes} = this.props;
        return (
            <div className = {classes.oneJobBox}>
                <div className = {classes.cardBox}>
                    <Card>
                        <CardContent>
                            <Typography variant = "h5" component = "h2" className={classes.cardTitle}>
                                {elem.nume}
                            </Typography>
                            <Typography variant = "body2" component = "p">
                                {elem.descriere}
                            </Typography>
                        </CardContent>
                    </Card>
                </div>
                <div className = {classes.buttonBox}>
                    <div className = {classes.buttonBox2}>
                        <Button variant="contained" color="primary" className = {classes.button}>
                            <BorderColorIcon className = {classes.editIcon} /> Edit
                        </Button>
                    </div>
                </div>
            </div>
        );
    }

    render() { 
        const {jobList, classes} = this.props;

        return (
            <div>
                <div className = {classes.jobsBox}>
                    {jobList.map((elem: any) => {return this.makeItem(elem)})}
                </div>
                <div className = {classes.nextButtonBox}>
                    <Button variant="contained" color="primary" className = {classes.nextButton}>
                        Next
                    </Button>
                </div>
            </div>
        );
    }
}
 
export default withStyles(styles)(UpdateJob);