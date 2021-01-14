import { Button,Input, Card, CardHeader, CardMedia, FormControl, FormControlLabel,  InputLabel, MenuItem, Radio, RadioGroup, Select, TextField, CardContent, Typography, CardActionArea } from '@material-ui/core';
import * as React from 'react';
import { withStyles, createStyles } from '@material-ui/core/styles';
import Service from "../remote/ServiceApi"

export interface UpdateCVProps {
    classes:any;
    imgSrc:string;
    varsta:string;
    gen:string;
    casatorit:string;
    educatie:string;
    munca:string;
    nume:string;
    buttonText:any;
    buttonFunction:any;
    handleChange(data: any): void;
}
 
export interface UpdateCVState {
    selectedImg:any;
}


const styles = createStyles({
    container : {
        width:'100%',
        display:'flex',
        flexDirection:'row',
        justifyContent:'space-between',
        marginLeft:'0px',
        marginRight:'0px',
        padding:'0px,'
    },
    containerItems : {
        width:'33%',
        padding:'10px',
        display:'flex',
        flexDirection:'column',
    },
    profileBox : {
        display:'flex',
        flexDirection:'row',
        height:'50%',
        width:'100%',
        marginBottom:'10%',
    },
    profilePictureBox : {
        width:'70%',
        marginRight:'2%'
    },
    profilePicture : {
        height:'100%',
    },
    profileButtonBox : {
        display:'inline-block',
        marginTop:'auto',
        marginBottom:'auto',
        justifyContent:'center',
    },
    profileButton : {
        padding:'10px',
    },
    varstaBox : {
        width:'100%',
        display:'flex',
        justifyContent:'center',
        marginBottom:'10%',
    },
    varsta : {
        width:'200px',
    },
    genBox : {
        width:'100%',
        display:'flex',
        justifyContent:'center',
        marginBottom:'10%',
        
    },
    genLabel : {
        display:'flex',
        justifyContent:'center'
    },
    nextButtonBox : {
        float:'right',
        marginRight:'1%',
        marginTop:'1%'
    },
    nextButton : {
        padding:'10px',
    },
    abc:{
        display:'flex',
        justifyContent:'center'
    }
});
 
class UpdateCV extends React.Component<UpdateCVProps, UpdateCVState> {

    private service:Service = new Service();
    handleData = (type: any) => (event: any) => {
        this.props.handleChange({
            [type]: event.target.value,
        });
    };

    handleImg =(type:string ) =>(event:any)=>{
        this.props.handleChange({
            [type]:URL.createObjectURL(this.state.selectedImg)
        })
    }

    varsta = () => {
        let lst = [];
        for(let i = 10; i <= 60; ++i) {
            lst[i] = i;
        }
        return lst;
    }

    buttonFunction= async()=>{
        const b=await this.toBase64(this.state.selectedImg)
        console.log(b, "asta e bb");
        this.props.buttonFunction(b);
    }

   toBase64 = (file:any) => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });

    render() { 
        const {classes, varsta,imgSrc ,gen, casatorit, educatie, munca, nume} = this.props;
        return (
        <div>
            <div className={classes.container}>
                <div className={classes.containerItems}>
                    <div className={classes.profileBox}>
                        <div className={classes.profilePictureBox}>
                            <Card className={classes.profilePicture}>
                                <div className={classes.abc}>
                                    <CardHeader
                                        title={nume}
                                    ></CardHeader>
                                </div>
                                <div>
                                    <img width="300px" height="300px" src={imgSrc} alt={nume}/>
                                </div>
                            </Card>
                        </div>
                        <div className={classes.profileButtonBox}>
                            <Button variant='contained' color='primary' onClick={
                                this.handleImg("imgSrc")
                            }  className={classes.profileButton}>
                                Incarca imagine
                            </Button>
                            <Input type="file" onChange={
                                (e:any)=>{
                                    this.setState({
                                        selectedImg:e.target.files[0]
                                    })
                                }
                            }></Input>
                        </div>
                    </div>
                    <div className={classes.varstaBox}>
                        <FormControl variant="outlined" className={classes.varsta}>
                        <InputLabel>Varsta</InputLabel>
                            <Select
                                value={varsta}
                                onChange={this.handleData("varsta")}
                                label="Varsta"
                                >
                                {this.varsta().map((item) => (
                                    <MenuItem value = {item}>{item}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
                    </div>
                    <div className={classes.genBox}>
                        <div>
                            <label className = {classes.genLabel}>Selectati genul: </label>
                            <RadioGroup aria-label="gender" name="gender1" value={gen} onChange={this.handleData("gen")} row>
                                <FormControlLabel value="male" control={<Radio />} label="Barbat" />
                                <FormControlLabel value="female" control={<Radio />} label="Femeie" />
                            </RadioGroup>
                        </div>
                    </div>
                    <div className={classes.genBox}>
                        <div className={classes.genContinut}>
                            <label className = {classes.genLabel}>Stare conjugala: </label>
                            <RadioGroup aria-label="Stare conjugala" name="gender1" value={casatorit} onChange={this.handleData("casatorit")} row>
                                <FormControlLabel value="Casatorit(a)" control={<Radio />} label="Casatorit(a)" />
                                <FormControlLabel value="Necasatorit(a)" control={<Radio />} label="Necasatorit(a)" />
                            </RadioGroup>
                        </div>
                    </div>
                </div>
                <div className={classes.containerItems}>
                <TextField
                        label="Specializare"
                        multiline
                        rows={24}
                        variant="outlined"
                        value={educatie}
                        onChange={this.handleData("educatie")}
                    />
                </div>
                <div className={classes.containerItems}>
                <TextField
                        label="Educaties"
                        multiline
                        rows={24}
                        variant="outlined"
                        value={munca}
                        onChange={this.handleData("munca")}
                    />
                </div>
            </div>
            <div className={classes.nextButtonBox}>
                <Button variant='contained' color='primary'  className={classes.nextButton} onClick={
                    this.buttonFunction
                }>
                    {this.props.buttonText}
                </Button>
            </div>
    </div>
        );
    }
}
 
export default withStyles(styles)(UpdateCV);