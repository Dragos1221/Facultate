const { request } = require("express");
const firebase = require("firebase/app"),
    express = require('express');

require("firebase/auth");
require("firebase/database");

// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyAP1WveZkyLo6rCwSnsNIJYTycZmEqGVwA",
  authDomain: "jobs-cv2.firebaseapp.com",
  databaseURL: "https://jobs-cv2-default-rtdb.europe-west1.firebasedatabase.app",
  projectId: "jobs-cv2",
  storageBucket: "jobs-cv2.appspot.com",
  messagingSenderId: "704414501420",
  appId: "1:704414501420:web:be1635e4d061c891fddf89",
  measurementId: "G-DH8CX6PYWH"
};

firebase.initializeApp(firebaseConfig);

const database = firebase.database();

const router = express.Router();

router.get('/welcome', (request, response) => {
    response.send('Bine ai venit')
});

router.get('/info', (request, response) => {
    response.send('instructiuni')
});

router.get('/job/:jobID', (request, response) => {
    const jobID = parseInt(request.params.jobID);
    database.ref('jobs').orderByChild('id').equalTo(jobID).once('value').then(snapshot => {
        const job = snapshot.val();
        if (job) {
            response.status(200).send(job);
        }
        else {
            response.status(400).send("Not found.");
        }
    });

});

router.get('/job/:jobID/cv/:positionOfCV', (request, response) => {
    let cvPos = parseInt(request.params.positionOfCV);
    let jobID = parseInt(request.params.jobID);

    database.ref('cvs').orderByChild('id').once('value').then(snapshot => {
        const cvList = snapshot.val();
        let ok = false;

        for (i = 1; i < Object.keys(cvList).length + 1; i++) {
            if (cvList[i].order_in_job === cvPos && cvList[i].job_id === jobID) {
                ok = true;
                response.status(200).send(cvList[i]);
            }
        }
        if (!ok) {
            response.status(400).send("Not found.");
        }
    });
});

router.get('/job/:jobID/chooseCV', (request, response) => {
    const jobID = parseInt(request.params.jobID);
    database.ref('cvs').orderByChild('job_id').equalTo(jobID).once('value').then(snapshot => {
        const job = snapshot.val();
        if (job) {
            response.status(200).send(job);
        }
        else {
            response.status(400).send("Not found.");
        }
    });
});

router.get('/finished', (request, response) => {
    response.send('Multumim');
});

router.get('/forjob/:id', (request, response) => {
    let jobID = parseInt(request.params.id);
    database.ref('cvs').once('value').then(snapshot => {
      const cvList = snapshot.val();
      let ok = false;
      if (cvList) {
        let answer = '[';
        cvList.forEach(element => {
          if (element.job_id == jobID) {
            ok = true;
            const elem = JSON.stringify(element);
            answer = answer.concat(elem + ',');
          }
        });
        if (ok) {
          answer = JSON.parse(answer.replace(/.$/, ']'));
          response.status(200).send(answer);
        } else {
          response.status(400).send("No cvs for this job.");
        }
        
      }
    });
  });

  router.get('/alljobs', (request, response) => {
    database.ref('jobs').orderByChild('order_in_list').once('value').then(snapshot => {
      const jobs = snapshot.val();
      let jobsOrdered = [];
      jobs.forEach(element => { jobsOrdered.push(element) });
      jobsOrdered.sort(function (a, b) {
        return a.order_in_list - b.order_in_list;
      });
      if (jobs) {
        response.status(200).send(jobsOrdered);
      } else {
        response.status(400).send("No Jobs.");
      }
    });
  })

module.exports = router;