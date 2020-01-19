import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { saveCustomer } from '../actions/creators';
import { Link } from 'react-router';

interface ICustomerCreateProps extends React.Props<any>{
    token?: string,
    localSaveCustomer?: Function
}

interface ICustomerCreateState {
    firstName: string,
    lastName: string,
    city: string,
    country: string,
    phone: string
}

function mapStateToProps(state: any, ownProps: any) { 
    return {
        token: state.loginReducer.token,
    };
}

function mapDispatchToProps(dispatch: any) {
    return {
        localSaveCustomer: bindActionCreators(saveCustomer, dispatch)
    };
}

class CustomerCreate extends React.Component<any, ICustomerCreateState> {
    constructor(props: ICustomerCreateProps) {
        super(props);

        this.state = {
            firstName: '',
            lastName: '',
            city: '',
            country: '',
            phone: ''
        };

        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleLastnameChange = this.handleLastnameChange.bind(this);
        this.handleCiudadChange = this.handleCiudadChange.bind(this);
        this.handlePaisChange = this.handlePaisChange.bind(this);
        this.handleTelefonoChange = this.handleTelefonoChange.bind(this);
        this.handleSaveCustomer = this.handleSaveCustomer.bind(this)
    }

    render() {
        let {customer} = this.props;
        let {
            firstName,
            lastName,
            city,
            country,
            phone
        } = this.state;
        return <div className="container-fluid container-background">
            <div className="row full-height-row">
                <div className="col-md-3 hidden-sm"></div>
                <div className="col-sm-12 col-md-6">
                    <div className="text-center">
                        <div className="panel panel-default panel-list text-left">
                            <div className="panel-body">
                                <h3>Nuevo Cliente</h3>
                                <br/>
                                <div>
                                    <div className="form-group">
                                        <label >Nombres</label>
                                        <input type="text" className="form-control" placeholder="Nombres"
                                        onChange={this.handleNameChange} value={firstName}/>
                                    </div>
                                    <div className="form-group">
                                        <label >Apellidos</label>
                                        <input type="text" className="form-control" placeholder="Apellidos"
                                        onChange={this.handleLastnameChange} value={lastName}/>
                                    </div>
                                    <div className="form-group">
                                        <label >Ciudad</label>
                                        <input type="text" className="form-control" placeholder="Ciudad"
                                        onChange={this.handleCiudadChange} value={city}/>
                                    </div>
                                    <div className="form-group">
                                        <label >Pais</label>
                                        <input type="text" className="form-control" placeholder="Pais"
                                        onChange={this.handlePaisChange} value={country}/>
                                    </div>
                                    <div className="form-group">
                                        <label >Teléfono</label>
                                        <input type="tel" className="form-control" placeholder="Teléfono"
                                        onChange={this.handleTelefonoChange} value={phone}/>
                                    </div>
                                </div>
                                <div className="text-right">
                                    <button className="btn btn-primary" onClick={(e)=> this.handleSaveCustomer()}>Guardar</button>
                                    &nbsp;&nbsp;&nbsp;
                                    <Link to={'/customers'} className="btn btn-danger">Cancelar</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="col-md-3 hidden-sm"></div>
            </div>
        </div>;
    };

    handleNameChange(event: any){
        let newVal = event.currentTarget.value;
        this.setState({firstName: newVal});
    }
    handleLastnameChange(event: any){
        let newVal = event.currentTarget.value;
        this.setState({lastName: newVal});
    }
    handleCiudadChange(event: any){
        let newVal = event.currentTarget.value;
        this.setState({city: newVal});
    }
    handlePaisChange(event: any){
        let newVal = event.currentTarget.value;
        this.setState({country: newVal});
    }
    handleTelefonoChange(event: any){
        let newVal = event.currentTarget.value;
        this.setState({phone: newVal});
    }

    handleSaveCustomer(){
        let { token, localSaveCustomer } = this.props
        let newCustomer = {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            city: this.state.city,
            country: this.state.country,
            phone: this.state.phone
        };
        localSaveCustomer(token, newCustomer);
    }

}

export default connect(mapStateToProps, mapDispatchToProps)(CustomerCreate);