import React, {useState} from "react";
import {Redirect} from 'react-router-dom';
// @material-ui/core components
import {makeStyles} from "@material-ui/core/styles";
import InputAdornment from "@material-ui/core/InputAdornment";
import Checkbox from "@material-ui/core/Checkbox";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Icon from "@material-ui/core/Icon";

// @material-ui/icons
import Email from "@material-ui/icons/Email";
// import LockOutline from "@material-ui/icons/LockOutline";
import Check from "@material-ui/icons/Check";

// core components
import GridContainer from "components/Grid/GridContainer.js";
import GridItem from "components/Grid/GridItem.js";
import Button from "components/CustomButtons/Button.js";
import CustomInput from "components/CustomInput/CustomInput.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";

import styles from "assets/jss/material-dashboard-pro-react/views/registerPageStyle";
import {renderErrors, validateEmail, validatePassword} from "../../variables/functions";
import myConfig from "../../variables/config.js";
const useStyles = makeStyles(styles);

export default function RegisterPage() {
    const [checked, setChecked] = useState([]);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [errors, setErrors] = useState({email: false, password: false, confirmPassword: false});
    const [redirectToLogin, setRedirectToLogin] = useState(false);
    const classes = useStyles();
    if (redirectToLogin) {
        return <Redirect to={"/auth/login-page"}/>
    }
    const backToLogin = () => {
        setRedirectToLogin(true);
    };
    const validateForm = (email, password, confirmPassword) => {
        const newErrors = {...errors};
        let isValid;
        if (email !== '') {
            isValid = validateEmail(email);
            if (isValid) {
                newErrors.email = false;
            } else {
                newErrors.email = "Invalid Email.";
            }
        }
        if (password !== '') {
            isValid = validatePassword(password);
            if (isValid) {
                newErrors.password = false;
            } else {
                newErrors.password = [
                    "Invalid password.",
                    "Must be 8 characters or more.",
                    "Min of one uppercase letter, one lowercase letter and one number."
                ];
            }
        }
        if (confirmPassword !== password) {
            newErrors.confirmPassword = "Password does not match.";
        } else {
            newErrors.confirmPassword = false;
        }
        setErrors(newErrors);
    };
    const emailInputCallback = value => {
        setEmail(value);
        validateForm(value, password, confirmPassword);
    };
    const passwordInputCallback = value => {
        setPassword(value);
        validateForm(email, value, confirmPassword);
    };
    const confirmPasswordCallback = value => {
        setConfirmPassword(value);
        validateForm(email, password, value);
    };
    const registerButtonCallback = event => {
        event.preventDefault();
        const newErrors = {...errors};
        const response= fetch(myConfig.BASEURL+`Player/Add`,{
			method:'POST',
			headers:{'Content-Type': 'application/json',
			// 'Access-Control-Allow-Origin': 'http://localhost:3000',
			// 'Access-Control-Allow-Credentials': 'true'
		   },
		
		   body:JSON.stringify({Id:email,Password:password,Email:email})
		}).then((response) => {
			return response.json();
		  })
		  .then((myJson) => {
			if(myJson.statusCode!==undefined)
			{

				if(myJson.errors[0].InnerException!==undefined)
				{
					setErrors(myJson.errors[0].InnerException.Message)
					console.log(myJson.statusCode);
				
				}
				else
				{
					setErrors(myJson.errors[0]);
					console.log(myJson.errors[0]);
				
				}
			}
			if(myJson.item1!==undefined)
			{
				window.location='/login';
			}
		
			console.log();
		  });
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
    const prepareErrors = () => {
        const errorsArray = [];
        if (errors.email !== false) {
            errorsArray.push(errors.email);
        }
        if (errors.password !== false) {
            errors.password.map(err => errorsArray.push(err));
        }
        if (errors.confirmPassword !== false) {
            errorsArray.push(errors.confirmPassword);
        }
        return errorsArray;
    };
    return (
        <div className={classes.container}>
            <GridContainer justify="center">
                <GridItem xs={12} sm={12} md={10}>
                    <Card className={classes.cardSignup}>
                        <h2 className={classes.cardTitle}>Register</h2>
                        <CardBody>
                            <GridContainer justify="center">
                                <GridItem xs={12} sm={8} md={5}>
                                    <Button simple color={"blue"} onClick={() => backToLogin()}>Back to sign in</Button>
                                    {renderErrors(prepareErrors())}
                                    <form className={classes.form}>
                                        <CustomInput
                                            formControlProps={{
                                                fullWidth: true,
                                                className: classes.customFormControlClasses
                                            }}
                                            inputProps={{
                                                startAdornment: (
                                                    <InputAdornment
                                                        position="start"
                                                        className={classes.inputAdornment}
                                                    >
                                                        <Email className={classes.inputAdornmentIcon}/>
                                                    </InputAdornment>
                                                ),
                                                value: email,
                                                onChange: e => emailInputCallback(e.target.value),
                                                placeholder: "Email..."
                                            }}
                                        />
                                        <CustomInput
                                            formControlProps={{
                                                fullWidth: true,
                                                className: classes.customFormControlClasses
                                            }}
                                            inputProps={{
                                                startAdornment: (
                                                    <InputAdornment
                                                        position="start"
                                                        className={classes.inputAdornment}
                                                    >
                                                        <Icon className={classes.inputAdornmentIcon}>
                                                            lock_outline
                                                        </Icon>
                                                    </InputAdornment>
                                                ),
                                                value: password,
                                                onChange: e => passwordInputCallback(e.target.value),
                                                placeholder: "Password..."
                                            }}
                                        />
                                        <CustomInput
                                            formControlProps={{
                                                fullWidth: true,
                                                className: classes.customFormControlClasses
                                            }}
                                            inputProps={{
                                                startAdornment: (
                                                    <InputAdornment
                                                        position="start"
                                                        className={classes.inputAdornment}
                                                    >
                                                        <Icon className={classes.inputAdornmentIcon}>
                                                            lock_outline
                                                        </Icon>
                                                    </InputAdornment>
                                                ),
                                                value: confirmPassword,
                                                onChange: e => confirmPasswordCallback(e.target.value),
                                                placeholder: "Confirm password..."
                                            }}
                                        />
                                        <FormControlLabel
                                            classes={{
                                                root: classes.checkboxLabelControl,
                                                label: classes.checkboxLabel
                                            }}
                                            control={
                                                <Checkbox
                                                    tabIndex={-1}
                                                    onClick={() => handleToggle(1)}
                                                    checkedIcon={
                                                        <Check className={classes.checkedIcon}/>
                                                    }
                                                    icon={<Check className={classes.uncheckedIcon}/>}
                                                    classes={{
                                                        checked: classes.checked,
                                                        root: classes.checkRoot
                                                    }}
                                                />
                                            }
                                            label={
                                                <span>
                          I agree to the{" "}
                                                    <a href="#pablo">terms and conditions</a>.
                        </span>
                                            }
                                        />
                                        <div className="g-recaptcha"
                                             data-sitekey="6Lci9JoUAAAAAActS_bymF7XBSA53_xML_NeHB9a"/>
                                        <div className={classes.center}>
                                            <Button
                                                type={"submit"}
                                                round color="blue"
                                                onClick={registerButtonCallback}
                                                disabled={checked.length === 0 || errors.email !== false || errors.password !== false || errors.confirmPassword !== false}>
                                                Sign up
                                            </Button>
                                        </div>
                                    </form>
                                </GridItem>
                            </GridContainer>
                        </CardBody>
                    </Card>
                </GridItem>
            </GridContainer>
        </div>
    );
}
