import React from "react";
import Danger from "components/Typography/Danger.js";

export const validateEmail = email => {
    const regex = new RegExp(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/);
    return regex.test(email);
};
export const validatePassword = password => {
    const regex = new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/);
    return regex.test(password);
};
export const formSubmitHandler = ( event, callback ) => {
    event.preventDefault();
    callback();
};
export const renderErrors = errors => {
    if (typeof errors === 'string') {
        return  <div className={'error-container'}>
            <Danger>{errors}</Danger>
        </div>;
    }
    return  <div className={'error-container'}>
            {errors.map(( error, index ) => <Danger key={index}>{error}</Danger>)}
    </div>;
};
