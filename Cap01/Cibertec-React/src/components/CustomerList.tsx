import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { getCustomerList } from '../actions/creators';
import { getCustomerCount } from '../actions/creators';
import { hashHistory } from 'react-router';
import { Link } from 'react-router';

interface ICustomerListProps extends React.Props<any> {
    token?: string,
    customers?: Array<any>,
    localGetCustomerList?: Function,
    localGetCustomerCount?: Function
}

interface ICustomerListState {
    page: number,
    pageSize: number,
    customerCount: number,
    maxPageNumber: number
};

function mapStateToProps(state: any, ownProps: any) {
    return {
        token: state.loginReducer.token,
        customers: state.customerReducer.customers,
        customerCount: state.customerReducer.customerCount
    };
}

function mapDispatchToProps(dispatch: any) {
    return {
        localGetCustomerList: bindActionCreators(getCustomerList, dispatch),
        localGetCustomerCount: bindActionCreators(getCustomerCount, dispatch)
    };
}

class CustomerList extends React.Component<any, ICustomerListState> {
    constructor(props: ICustomerListProps) {
        super(props);

        this.state = {
            page: 1,
            pageSize: 20,
            customerCount: 20,
            maxPageNumber: 1
        };

        this.handlePagePrev = this.handlePagePrev.bind(this);
        this.handlePageNext = this.handlePageNext.bind(this);
    }

    componentDidMount() {
        let { token, customerCount } = this.props;
        let { page, pageSize } = this.state;
        this.props.localGetCustomerList(token, page, pageSize);
        this.props.localGetCustomerCount(token);
    }

    render() {
        let { customers } = this.props;
        let panelClassName = this.props.customers.length > 0 ? "panel-list" : "panel-list panel-list--empty";
        return <div className="container-fluid container-background">
            <div className="row full-height-row">
                <div className="col-md-3 hidden-sm"></div>
                <div className="col-sm-12 col-md-6">
                    <div className="text-center">
                        <div className={`panel panel-default text-left ${panelClassName}`}>
                            <div className="panel-body">
                                <h3>Lista de clientes</h3>
                                <table className="table table-bordered table-hover table-condensed">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Nombre Completo</th>
                                            <th>Ciudad</th>
                                            <th>País</th>
                                            <th>Teléfono</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {customers.map((item) => {
                                            return <tr key={item.id}>
                                                <td>{item.id}</td>
                                                <td>{`${item.firstName} ${item.lastName}`}</td>
                                                <td>{item.city}</td>
                                                <td>{item.country}</td>
                                                <td>{item.phone}</td>
                                                <td>
                                                    <Link to={`/customerview/${item.id}`}><span className="glyphicon glyphicon-eye-open list-icon text-primary"></span></Link>
                                                    <Link to={`/customeredit/${item.id}`}><span className="glyphicon glyphicon-pencil list-icon text-primary"></span></Link>
                                                </td>
                                            </tr>
                                        })}
                                    </tbody>
                                </table>

                                <div className="text-center">
                                    <div className="btn-group" role="group">
                                        <button type="button" className="btn btn-success" onClick={this.handlePagePrev}>&laquo; Anterior</button>
                                        <button type="button" className="btn btn-success" onClick={this.handlePageNext}>Siguiente &raquo;</button>
                                    </div>
                                </div>

                                <div className="text-right">
                                    <Link to="/customercreate" className="btn btn-primary">Agregar Cliente</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="col-md-3 hidden-sm"></div>
            </div>
        </div>;
    };

    handlePagePrev(event: any) {
        event.preventDefault();
        let { token } = this.props
        let { page, pageSize } = this.state
        let newPage = page - 1 > 0 ? page - 1 : page;

        this.setState({ page: newPage }, () => {
            this.props.localGetCustomerList(token, this.state.page, pageSize);
        });

    }

    handlePageNext(event: any) {
        event.preventDefault();
        let { token, customerCount } = this.props
        let { page, pageSize } = this.state

        let maxPage = (customerCount % pageSize > 0 ? (customerCount / pageSize) + 1 : (customerCount / pageSize));        
        let newPage = page + 1;
        if (newPage <= maxPage) {
            this.setState({ page: newPage }, () => {
                this.props.localGetCustomerList(token, this.state.page, pageSize);
            });
        }
    }

}

export default connect(mapStateToProps, mapDispatchToProps)(CustomerList);