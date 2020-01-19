import * as types from '../actions/types';
import { hashHistory } from 'react-router';
const INITIAL_STATE = {};

export function customerReducer(state = INITIAL_STATE, action: any) {
    switch (action.type) {        
        case types.GOT_CUSTOMERS:
            return { ...state, customers: action.customers };
        case types.GOT_CUSTOMERS_COUNT:
            return { ...state, customerCount: action.customerCount };        
        case types.GOT_CUSTOMER:
            return { ...state, customer: action.customer };
        case types.CUSTOMER_CREATED:
            hashHistory.push('/customers');
            break;
        case types.CUSTOMER_UPDATED:
            hashHistory.push(`/customerview/${action.id}`);
            break;
        case types.CUSTOMER_DELETED: 
            hashHistory.push('/customers');
            break;
    }

    return state;
}