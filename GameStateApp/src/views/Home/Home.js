import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";

// @material-ui/icons
//import Dashboard from "@material-ui/icons/Dashboard";
//import Schedule from "@material-ui/icons/Schedule";
import Info from "@material-ui/icons/FiberNew";
import LocationOn from "@material-ui/icons/NoteAdd";
import Announcement from "@material-ui/icons/Announcement";
//import HelpOutline from "@material-ui/icons/HelpOutline";

// core components
import GridContainer from "components/Grid/GridContainer.js";
import GridItem from "components/Grid/GridItem.js";
import NavPills from "components/NavPills/NavPills.js";
//import Accordion from "components/Accordion/Accordion.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";

import { cardTitle } from "assets/jss/material-dashboard-pro-react.js";
import ReactTables from "views/Settings/ManageUser";

const styles = {
  cardTitle,
  pageSubcategoriesTitle: {
    color: "#3C4858",
    textDecoration: "none",
    textAlign: "center"
  },
  cardCategory: {
    margin: "0",
    color: "#999999"
  }
};

const useStyles = makeStyles(styles);

export default function Panels() {
  const classes = useStyles();
  return (
    <div>
      <GridContainer justify="center">
        <GridItem xs={12} sm={12} md={12}>
          <NavPills
            color="warning"
            alignCenter
            tabs={[
              {
                tabButton: "Requests(39)",
                tabIcon: Info,
                tabContent: (
                  <Card>
                    <CardHeader>
                      <h4 className={classes.cardTitle}>
                        New requests
                      </h4>
                      <p className={classes.cardCategory}>
                        Template exists - acknowledge client
                      </p>
                    </CardHeader>
                    <CardBody>
                      <ReactTables />
                    </CardBody>
                  </Card>
                )
              },
              {
                tabButton: "No Templates(3)",
                tabIcon: LocationOn,
                tabContent: (
                  <Card>
                    <CardHeader>
                      <h4 className={classes.cardTitle}>
                        New requests without templates
                      </h4>
                      <p className={classes.cardCategory}>
                        No templates - initiate template design or decline
                      </p>
                    </CardHeader>
                    <CardBody>
                      <ReactTables />
                    </CardBody>
                  </Card>
                )
              },
              {
                tabButton: "Attention(17)",
                tabIcon: Announcement,
                tabContent: (
                  <Card>
                    <CardHeader>
                      <h4 className={classes.cardTitle}>
                        Attention
                      </h4>
                      <p className={classes.cardCategory}>
                        Items require your attention
                      </p>
                    </CardHeader>
                    <CardBody>
                      <ReactTables />
                    </CardBody>
                  </Card>
                )
              }
            ]}
          />
        </GridItem>
      </GridContainer>
    </div>
  );
}
