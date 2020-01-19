import * as types from '../actions/types';
import { hashHistory } from 'react-router';
const INITIAL_STATE = {};

export function loginReducer(state = INITIAL_STATE, action: any) {
    switch (action.type) {
        case types.GOT_TOKEN: 
            return {...state, token: action.token}
    }

    return state;
}