import * as React from 'react';
import Login from '../../src/components/Login';
import axios, { AxiosInstance } from 'axios';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import serviceApi from "../remote/ServiceApi";


interface LoginPageProps extends RouteComponentProps {}

interface LoginPageState {
	password: string;
	email: string;
	isError: boolean;
	errorMessage: string;
}

class LoginPage extends React.Component<LoginPageProps, LoginPageState> {
	private service:serviceApi = new serviceApi();
	constructor(props: LoginPageProps) {
		super(props);
		this.state = {
			password: '',
			email: '',
			isError: false,
			errorMessage: 'Parola nu este corecta.',
		};
	}

	handleChange = (data: any) => {
		this.setState({
			...data,
			isError: false,
		});
	};
	clearUserData() {
		this.setState({
			password: '',
			isError: true,
		});
	}

	submit = async() => {
		try {
			const result = await this.service.login({...this.state})
			this.props.history.push("/home");
		} catch (error) {
			//const { response } = error;
			this.setState({
				isError: true,
			});
			this.clearUserData();
		}
	};

	render() {
		return (
			<div>
				<Login
					{...this.state}
					handleChange={this.handleChange}
					submit={this.submit}
				></Login>
			</div>
		);
	}
}

export default withRouter(LoginPage);
