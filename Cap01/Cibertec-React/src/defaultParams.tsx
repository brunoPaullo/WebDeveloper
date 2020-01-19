export default function DefaultParams(){
    let defaultCustomer = {
        "Id":"",
        "ComapanyName":"",
        "contactName":"",
        "City":"",
        "Country":"",
        "Phone":""

    }
    return {
        customerReducer:{
            token:"",
            customers:Array<any>()
        }
    };
}