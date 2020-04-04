import React, { useState } from "react";
import { Redirect } from 'react-router-dom';
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";

// core components
import Button from "components/CustomButtons/Button.js";
import CustomInput from "components/CustomInput/CustomInput.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import CardAvatar from "components/Card/CardAvatar.js";
import CardFooter from "components/Card/CardFooter.js";
import Checkbox from "@material-ui/core/Checkbox";
import Check from "@material-ui/icons/Check";
import FormControlLabel from "@material-ui/core/FormControlLabel";

import styles from "assets/jss/material-dashboard-pro-react/views/lockScreenPageStyle.js";
import {formSubmitHandler, renderErrors, validatePassword} from "../../variables/functions";
import myConfig from '../../variables/config.js';


const useStyles = makeStyles(styles);

export default function LockScreenPage(props) {
    const { email } = props.location;
    const [cardAnimaton, setCardAnimation] = useState("cardHidden");
    const [backToLogin, setBackToLogin] = useState(email === undefined || email === '');
    const [passwordTrials, setPasswordTrials] = useState(0);
    const [errors, setErrors] = useState(   []);
    const [password, setPassword] = useState("");
    const [checked, setChecked] = useState([]);
    const [redirectToForgotPassword, setRedirectToForgotPassword] = useState(false);
    const [redirectToHome, setRedirectToHome] = useState(false);
    const [lockPage, setLockPage] = useState(false);
    const [lockPageTimer, setLockPageTimer] = useState(10);
    const classes = useStyles();
    if ( lockPage ) {
        setTimeout( () => {
            let newTime = lockPageTimer;
            if (newTime === 0) {
                clearTimeout();
                return;
            }
            newTime--;
            setLockPageTimer(newTime);
        }, 1000 );
    }
    if (backToLogin) {
        clearTimeout();
        return <Redirect to={{
            pathname: '/auth/login-page',
            email
        }} />;
    }
    if (redirectToHome) {
        return <Redirect to={"/admin/dashboard"}/>
    }
    setTimeout(function() {
        setCardAnimation("");
    }, 700);
    const forgotPasswordCallback = () => {
        setRedirectToForgotPassword(true);
    };
    const handleToggle = value => {
        const currentIndex = checked.indexOf(value);
        const newChecked = [...checked];

        if (currentIndex === -1) {
            newChecked.push(value);
        } else {
            newChecked.splice(currentIndex, 1);
        }
        setChecked(newChecked);
    };
    const signIn =  ()  => {
        const staySigned = checked.length;
        const regexValidation = validatePassword(password);
        const passwordErrors = [];
        let failTrials = passwordTrials;
        if (!regexValidation) {
            passwordErrors.push("Invalid password.");
            passwordErrors.push("Must be 8 characters or more.");
            passwordErrors.push("Min of one uppercase letter, one lowercase letter and one number.");
            console.log("fail");
        }
        if (!passwordErrors.length) {

              fetch(myConfig.BASEURL+'Login',{
                method:'POST',
                 headers:{'Content-Type': 'application/json',
                 'Access-Control-Allow-Origin': 'http://localhost:3000',
                 'Access-Control-Allow-Credentials': 'true'
                },
                 body:JSON.stringify({Login:email,Password:password})
                }).then((response) => {
                    return response.json();
                  })
                  .then((myJson) => {
                    //myJson.statusCode==401?setIsSuccess(true):setIsSuccess(false);
                    // if(IsSuccess)
                    // {
                        if(myJson.statusCode===401)
                        {
                            setErrors(["Invalid Login"]);
                            passwordErrors.push("Wrong username/password.");
                            failTrials++;
                            setPasswordTrials(failTrials);
                            if (failTrials === 5) {
                                passwordErrors.push("Unsuccessful sign in attempts. Please wait 10 seconds and try again. Thank you.");
                                setLockPage(true);
                            // setIsSuccess(true);
                        }
                    }
                        else{
                            // setIsSuccess(false);
                        const header = {
                            'Content-Type': 'application/json',
                            'Authorization':`Bearer ${myJson.token}`
                        };
                        console.log(myJson.token)
                        sessionStorage.setItem('token',JSON.stringify(header));
                        sessionStorage.setItem('user',JSON.stringify(myJson.user))
                        var obj = sessionStorage.token;
                        setRedirectToHome(true);
                        console.log(obj);
                        return window.location='/admin';
                             }
                       				
});
        


            
            }
        
        setErrors(passwordErrors);
        console.log(passwordErrors, password, staySigned, passwordTrials);
    };
    const inputCallback = event => {
        const value = event.target.value;
        setPassword(value);
    };
    if (redirectToForgotPassword) {
        clearTimeout();
        return <Redirect to={{pathname: "/auth/forgot-password"}}/>;
    }
    const renderButton = () => {
        return lockPage ?
            <Button
                color="blue" round
                disabled={ lockPageTimer !== 0 }
                onClick={ () => setBackToLogin(true) }
            >
                Back to sign in{ lockPageTimer !== 0 ? <span className={"lock-screen-timer"}> - { lockPageTimer }</span> : null }
            </Button>
            : <Button
                color="blue" round
                disabled={!validatePassword(password)}
                onClick={ () => signIn()}
            >
                Unlock
            </Button>;
    };
    const renderBody = () => {
        if ( lockPage ) {
            return <CardBody profile>
                <h4 className={classes.cardTitle}>Lock Screen</h4>
                { errors.length || passwordTrials === 5 ? renderErrors(errors) : null}
            </CardBody>;
        } else {
            return <CardBody profile>
                <h4 className={classes.cardTitle + " lock-screen-title"}>
                    <Button color={"blue"} className={"lock-screen-back"} simple onClick={ () => {
                        setBackToLogin(true);
                    }}><i className={"fa fa-arrow-left"}/></Button>
                    {email}
                </h4>
                { errors.length || passwordTrials === 5 ? renderErrors(errors) : null}
                <CustomInput
                    labelText="Enter Password"
                    id="login-password"
                    formControlProps={{
                        fullWidth: true
                    }}
                    inputProps={{
                        type: "password",
                        autoComplete: "off",
                        value: password,
                        onChange: inputCallback
                    }}
                />
                <div
                    className={
                        classes.checkboxAndRadio +
                        " " +
                        classes.checkboxAndRadioHorizontal +
                        " lock-screen-check"
                    }
                >
                    <FormControlLabel
                        control={
                            <Checkbox
                                tabIndex={-1}
                                onClick={() => handleToggle(1)}
                                checkedIcon={
                                    <Check className={classes.checkedIcon} />
                                }
                                icon={<Check className={classes.uncheckedIcon} />}
                                classes={{
                                    checked: classes.checked,
                                    root: classes.checkRoot
                                }}
                            />
                        }
                        classes={{
                            label: classes.label,
                            root: classes.labelRoot
                        }}
                        label="Stay signed in."
                    />
                </div>
                <Button
                    className={"lock-screen-forgot-password"}
                    simple color={"blue"}
                    onClick={() => forgotPasswordCallback()}
                >Forgotten your password?</Button>
            </CardBody>;
        }
    };
    return (
    <div className={classes.container}>
      <form onSubmit={ e => formSubmitHandler(e, () => {signIn()})}>
        <Card
          profile
          className={classes.customCardClass + " " + classes[cardAnimaton]}
        >
          <CardAvatar profile className={classes.cardAvatar}>
              <a className={"lock-screen-avatar"} href="#pablo" onClick={e => e.preventDefault()}>
                <i className={'fa fa-user fa-4x'} />
              </a>
          </CardAvatar>
          { renderBody() }
          <CardFooter className={classes.justifyContentCenter}>
              { renderButton() }
          </CardFooter>
        </Card>
      </form>
    </div>
  );
}
