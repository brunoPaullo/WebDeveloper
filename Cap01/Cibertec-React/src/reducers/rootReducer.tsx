import { combineReducers } from 'redux';
import { loginReducer } from './authentication';
import { customerReducer } from './customers';


const rootReducer = combineReducers({
    loginReducer,
    customerReducer
});

export default rootReducer;