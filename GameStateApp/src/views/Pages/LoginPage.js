import React, {useState} from "react";
import { Link, Redirect } from 'react-router-dom';
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import InputAdornment from "@material-ui/core/InputAdornment";
import Icon from "@material-ui/core/Icon";
import SweetAlert from "react-bootstrap-sweetalert";
import Warning from "components/Typography/Warning.js";

// @material-ui/icons
import Face from "@material-ui/icons/Face";
import Email from "@material-ui/icons/Email";
import Check from "@material-ui/icons/Check";
import Clear from "@material-ui/icons/Clear";

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

const inputChangeCallback = ( email, setEmailError, setEmail ) => {
    const isValid = validateEmail(email);
    if (!isValid) {
        setEmailError(true);
    } else {
        setEmailError(false);
    }
    setEmail(email);
};
const buttonCallback = ( setRedirectToLock, setEmail ) => {
    const email = document.getElementById("email").value;
    setEmail(email);
    setRedirectToLock(true);
};

export default function LoginPage(props) {
  const [cardAnimaton, setCardAnimation] = useState("cardHidden");
  const [redirectToLock, setRedirectToLock] = useState(false);
  const initialEmailState = props.location.email ? props.location.email : '';
  const [email, setEmail] = useState(initialEmailState);
  const [emailError, setEmailError] = useState(!validateEmail(email));
  const classes = useStyles();
    if (redirectToLock) {
        clearTimeout();
        return <Redirect to={{
          pathname: '/auth/lock-screen-page',
          email
      }}/>;
    }
    setTimeout(function() {
        setCardAnimation("");
    }, 700);
    return (
    <div className={classes.container}>
      <GridContainer justify="center">
        <GridItem xs={12} sm={6} md={4}>
          <form onSubmit={ e => formSubmitHandler(e, () => buttonCallback(setRedirectToLock, setEmail))}>
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
                  <h3 className={classes.cardTitle}>Log in</h3>
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
                    endAdornment: (
                      <InputAdornment position="end">
                          { emailError === false ? <Check
                              className={classes.inputAdornmentIconSuccess}
                          /> : null }
                          <Email className={classes.inputAdornmentIcon} />
                      </InputAdornment>
                    ),
                      value: email,
                      onChange: e => inputChangeCallback(e.target.value, setEmailError, setEmail)
                  }}
                />
                  <p>No account? <Link to={'/auth/register-page'}>Sign up here</Link>.</p>
              </CardBody>
              <CardFooter className={classes.justifyContentCenter}>
                <Button disabled={emailError !== false} color="blue" size="lg" block onClick={ () => buttonCallback(setRedirectToLock, setEmail) }>
                  NEXT
                </Button>
              </CardFooter>
            </Card>
          </form>
        </GridItem>
      </GridContainer>
    </div>
  );
}
