import * as React from "react";
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { hashHistory } from 'react-router';
import { loginUser } from '../actions/creators';


interface ILoginState {
    email?: string;
    password?: string;
}

interface ILoginProps extends React.Props<any>{
    token?: string,
    customers?: any[];
    localLoginUser?: Function,
}

function mapStateToProps(state: any, ownProps: any) { 
    return {
        token: state.loginReducer.token,
        customers: state.customerReducer.customers
    };
}

function mapDispatchToProps(dispatch: any) {
    return {
        localLoginUser: bindActionCreators(loginUser, dispatch),
    };
}

class Login extends React.Component<any, ILoginState> {
    constructor(props: ILoginProps) {
        super(props);
        this.state = { 
            email: 'bruno.paullo@cibertec.com.pe',
            password: 'CBT12345'
        }

        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleLoginUser = this.handleLoginUser.bind(this);
    }

    componentWillReceiveProps(nextProps: any) {
        if (nextProps.token !== '')
            hashHistory.push('/customers');
    }

    render() {
        let {
            email,
            password
        } = this.state;

        return <div className="container-fluid container-background">
            <div className="row full-height-row">
                <div className="col-md-3 hidden-sm"></div>
                <div className="col-sm-12 col-md-6">
                    <div className="text-center">
                        <div className="panel panel-default panel-login text-left">
                            <div className="text-center">
                                <div><img src="assets/imgs/reactdux.png" className="login-header-img" /></div>
                            </div>
                            <div className="panel-body">
                                <h3>Iniciar sesión</h3>
                                <form>
                                    <div className="form-group">
                                        <label >Email</label>
                                        <input type="email" className="form-control"  placeholder="Email" 
                                        onChange={this.handleEmailChange} value={email}/>
                                    </div>
                                    <div className="form-group">
                                        <label >Password</label>
                                        <input type="password" className="form-control" placeholder="Password" 
                                        onChange={this.handlePasswordChange} value={password}/>
                                    </div>
                                    <button className="btn btn-primary btn-block" onClick={this.handleLoginUser}>Entrar</button>
                                </form>
                            </div>
                        </div>
                    </div>        
                </div>
                <div className="col-md-3 hidden-sm"></div>
            </div>
        </div>
    }

    handleEmailChange (event: any) {
        let newVal = event.currentTarget.value;
        this.setState({email: newVal});
    }

    handlePasswordChange (event: any) {
        let newVal = event.currentTarget.value;
        this.setState({password: newVal});
    }

    handleLoginUser(event: any) {
        event.preventDefault();
        let {
            email,
            password
        } = this.state;

        this.props.localLoginUser(email, password);
    }

}

export default connect(mapStateToProps, mapDispatchToProps)(Login);