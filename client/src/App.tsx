import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

const title = 'Welcome to Reactivities';

function App() {
  const [activities, setActivities] = useState<Acitivity[]>([]);

  useEffect(() => {
    axios.get<Acitivity[]>('https://localhost:5001/api/activities')
      .then(response => setActivities(response.data))
      .catch(error => console.error('Error fetching activities:', error));
  }, []);

  return (
    <>
      <Typography variant="h3" className="app" style={{ color: 'red' }}>{title}</Typography>
      <List>
        {activities.map(activity => (
          <ListItem key={activity.id}><ListItemText>{activity.title}</ListItemText></ListItem>
        ))}
      </List>
    </>
  )
}

export default App
