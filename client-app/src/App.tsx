import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { act } from 'react-dom/test-utils';
import { Header, List } from 'semantic-ui-react';

function App() {

  //uses the useState Hook
  //A setActivities method that is going into "activities variable"
  const [activities, setActivities] = useState([]);

  //get the activities once so that we can populate the "activities" state above
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities'/>
        <List>
        {activities.map((activity: any) => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
