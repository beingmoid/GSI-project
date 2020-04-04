import React, {useState} from "react";
import { Link, Redirect } from 'react-router-dom';
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import InputAdornment from "@material-ui/core/InputAdornment";

// @material-ui/icons
import Email from "@material-ui/icons/Email";
import Check from "@material-ui/icons/Check";

// import LockOutline from "@material-ui/icons/LockOutline";

// core components
import GridContainer from "components/Grid/GridContainer.js";
import GridItem from "components/Grid/GridItem.js";
import CustomInput from "components/CustomInput/CustomInput.js";
import Button from "components/CustomButtons/Button.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import CardHeader from "components/Card/CardHeader.js";
import CardFooter from "components/Card/CardFooter.js";

import styles from "assets/jss/material-dashboard-pro-react/views/loginPageStyle.js";
import {formSubmitHandler, renderErrors, validateEmail} from "../../variables/functions";

const useStyles = makeStyles(styles);

export default function ForgotPasswordPage(props) {
    const [cardAnimaton, setCardAnimation] = useState("cardHidden");
    const [activationCodeLayout, setActivationCodeLayout] = useState(false);
    const [activationCode, setActivationCode] = useState('');
    const [email, setEmail] = useState('');
    const [emailError, setEmailError] = useState(!validateEmail(email));
    const classes = useStyles();
    setTimeout(function() {
        setCardAnimation("");
    }, 700);
    const inputChangeCallback = value => {
        const isValid = validateEmail(value);
        if (!isValid) {
            setEmailError(true);
        } else {
            setEmailError(false);
        }
        setEmail(value);
    };
    const buttonCallback = () => {
        const email = document.getElementById("email").value;
        setEmail(email);
        setActivationCodeLayout(true);
    };
    const codeInputChangeCallback = value => {
        setActivationCode(value);
    };
    const codeButtonCallback = () => {
        console.log(activationCode);
    };
    const renderButton = () => {
        return activationCodeLayout ?
            <Button disabled={activationCode === ''} color="blue" size="lg" block onClick={ () => codeButtonCallback() }>
                Submit Code
            </Button>
            : <Button disabled={emailError !== false} color="blue" size="lg" block onClick={ () => buttonCallback() }>
            Send Code
        </Button>;
    };
    return (
        <div className={classes.container}>
            <GridContainer justify="center">
                <GridItem xs={12} sm={6} md={4}>
                    <form onSubmit={ e => formSubmitHandler(e, () => buttonCallback())}>
                        <Card login className={classes[cardAnimaton]}>
                            <CardHeader
                                className={`${classes.cardHeader}`}
                                color="blue"
                            >
                                <div className={'logo-header'}>
                                    <span className={'company-logo'}>L</span>
                                    <span className={'company-name'}>
                          PLACEHOLDER
                      </span>
                                </div>
                                <h3 className={classes.cardTitle}>Forgot your password?</h3>
                            </CardHeader>
                            <CardBody>
                                { emailError !== false && email !== '' ?
                                    renderErrors("Invalid Email")
                                    : null }
                                <CustomInput
                                    labelText="Your Email..."
                                    id="email"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                    inputProps={{
                                        disabled: activationCodeLayout,
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                { emailError === false ? <Check
                                                    className={classes.inputAdornmentIconSuccess}
                                                /> : null }
                                                <Email className={classes.inputAdornmentIcon} />
                                            </InputAdornment>
                                        ),
                                        value: email,
                                        onChange: e => inputChangeCallback(e.target.value)
                                    }}
                                />
                                { activationCodeLayout ?
                                    <CustomInput
                                        labelText="Activation Code"
                                        id="activation-code"
                                        formControlProps={{
                                            fullWidth: true
                                        }}
                                        inputProps={{
                                            value: activationCode,
                                            onChange: e => codeInputChangeCallback(e.target.value)
                                        }}
                                    />
                                : null }
                                <Link to={'/auth/login-page'}><Button className={"lock-screen-forgot-password"} color={"blue"} simple>Back to sign in.</Button></Link>
                            </CardBody>
                            <CardFooter className={classes.justifyContentCenter}>
                                { renderButton() }
                            </CardFooter>
                        </Card>
                    </form>
                </GridItem>
            </GridContainer>
        </div>
    );
}
