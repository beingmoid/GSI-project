import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import DialogTitle from '@material-ui/core/DialogTitle';
import {InputLabel,Select, MenuItem,Divider,Slide,IconButton,Collapse} from '@material-ui/core';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import myConfig from '../../variables/config';

const useStyles = makeStyles({
  root: {
    maxWidth: 345,
  },
  media: {
    height: 140,
  },
});

export default function MediaCard() {
  const classes = useStyles();
  const [open,setOpen]= React.useState(false);
  const [type,setType] =React.useState(0);
  const [name,setName]=React.useState('');
  const handleClose = () => {
    setOpen(false);
  };
  async function CreateTeam()
  {
    
      const request = {
        method:'POST',
        headers:JSON.parse(sessionStorage.token===undefined ? '{}':sessionStorage.token),

       body:JSON.stringify({TeamName:name,TeamType:type})
    };
    console.log(request);

    const response= fetch(myConfig.BASEURL+'Team/',{
        method:'POST',
        headers:JSON.parse(sessionStorage.token===undefined ? '{}':sessionStorage.token),
       body:JSON.stringify({TeamName:name,TeamType:type})
    }).then((response) => {
        
        return response.json();
      })
      .then((myJson) => {
          if(myJson!=null)
          { 
            setOpen(false);
           
          }
     console.log(myJson);
      });
      return response;
     
  }
  return (
    <div>
    <Card fullWidth>
      <CardActionArea>
        <CardMedia
          className={classes.media}
          image=""
          title="Contemplative Reptile"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            Lizard
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p">
            Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging
            across all continents except Antarctica
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          Join Team
        </Button>
        <Button size="small" color="primary" onClick={()=> setOpen(true)}>
          Create Your Own Team
        </Button>
      </CardActions>
    </Card>
    <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title" key={"Team"}>
        <DialogTitle id="form-dialog-title">Create new Team</DialogTitle>
        <DialogContent>
          <DialogContentText>
            To create new team, please enter name and type of game here.
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            id="TeamName"
            label="Team name"
            type="email"
            fullWidth
            onChange={(e)=> setName(e.target.value)}
          />
          <Divider/>
          <InputLabel>Team Type</InputLabel>
        <Select fullWidth onChange={(e)=> setType(e.target.value)}>
          <MenuItem value={1}>CSGO</MenuItem>
          <MenuItem value={2}>DOTA2</MenuItem>
        </Select>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={CreateTeam} color="primary">
            Create
          </Button>
         
        </DialogActions>
      </Dialog>
    </div>
  );
}
