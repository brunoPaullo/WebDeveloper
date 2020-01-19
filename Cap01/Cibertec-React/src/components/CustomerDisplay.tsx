import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { getCustomer, deleteCustomer } from '../actions/creators';
import { Link } from 'react-router';

interface ICustomerDisplayProps extends React.Props<any>{
    token?: string,
    customer?: any,
    localGetCustomer?: Function,
    localDeleteCustomer?: Function,
}

function mapStateToProps(state: any, ownProps: any) { 
    return {
        token: state.loginReducer.token,
        customer: state.customerReducer.customer
    };
}

function mapDispatchToProps(dispatch: any) {
    return {
        localGetCustomer: bindActionCreators(getCustomer, dispatch),
        localDeleteCustomer: bindActionCreators(deleteCustomer, dispatch)
    };
}

class CustomerDisplay extends React.Component<any,any> {
    constructor(props: ICustomerDisplayProps) {
        super(props);

        this.handlerCustomerDelete =  this.handlerCustomerDelete.bind(this);
    }

    componentDidMount(){
        this.props.localGetCustomer(this.props.token, this.props.params.id);
    }

    render() {
        let {customer} = this.props;
        return <div className="container-fluid container-background">
            <div className="row full-height-row">
                <div className="col-md-3 hidden-sm"></div>
                <div className="col-sm-12 col-md-6">
                    <div className="text-center">
                        <div className="panel panel-default panel-list text-left">
                            <div className="panel-body">
                                <h3>{`Cliente ${customer.firstName} ${customer.lastName}`}</h3>
                                <br/>
                                <ul className="list-group">
                                    <li className="list-group-item"><span><strong>ID:</strong></span> {customer.id}</li>
                                    <li className="list-group-item"><span><strong>Ciudad:</strong></span> {customer.city}</li>
                                    <li className="list-group-item"><span><strong>País:</strong></span> {customer.country}</li>
                                    <li className="list-group-item"><span><strong>Teléfono:</strong></span> {customer.phone}</li>
                                </ul>
                                <div className="text-right">
                                    <Link className="btn btn-primary" to={`/customeredit/${customer.id}`}>Editar Cliente</Link>
                                    &nbsp;&nbsp;&nbsp;
                                    <button className="btn btn-warning" onClick={(e)=> this.handlerCustomerDelete(customer.id)}>Eliminar Cliente</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="col-md-3 hidden-sm"></div>
            </div>
        </div>;
    };

    handlerCustomerDelete(id: string) {
        this.props.localDeleteCustomer(this.props.token, id);
        
    }

}

export default connect(mapStateToProps, mapDispatchToProps)(CustomerDisplay);