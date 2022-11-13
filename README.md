# Score Board

## Overview

This api allows recording of a user's score for a specific game. In order for this to occur a few operation must happen before a score can be record.

1. Create Game that scores and players can be associated with.
2. Once a player's name is entered and a score are setup, a request can be made to record it with the service.

Also a playground to try out Domain Drive Design, Clean Architecture, and new tech.

## Tech

TBD

Status: In Development

### Game setup

Create game for scoreboard.

Request
```json
{
  "name": "Asteroids",
  "createdBy": "Jordan Walker"
}
```
Response
```json
{
  "data": {
    "id": "99852beb-6fe3-4927-86b1-ec736e754795",
    "name": "Asteroids",
    "isActive": true,
    "creationDate": "2022-11-12T16:38:18.993842-06:00"
  },
  "message": "Successfully created game."
}
```

### Player name select

Choose a display name for the scoreboard.

Request
```json
{
  "name": "jwalker2276"
}
```

Response
```json
{
  "data": {
    "isNameAvailable": true,
    "isNameAllowed": true
  },
  "message": "Successfully checked name."
}
```

### Score creation

Record score with requested player name.

Request
```json
{
  "gameId": "99852beb-6fe3-4927-86b1-ec736e754795",
  "playerName": "jwalker2276",
  "score": 25123
}
```

Response
```json
{
  "data": {
    "gameId": "99852beb-6fe3-4927-86b1-ec736e754795",
    "score": {
      "value": 25123,
      "recordDate": "2022-12-12T16:38:18.993842-06:00"
    },
    "player": {
      "displayName": "jwalker2276",
    }
  },
  "message": "Successfully created score."
}
```

### Scoreboard setup

Setup a scoreboard

Request
```json
{
  "gameId": "99852beb-6fe3-4927-86b1-ec736e754795",
  "name": "Top ten scores of all time.",
  "maxNumberOfScores": 10,
  "sortby": "Descending"
}
```

Response
```json
{
  "data": [
    {
      "score": {
        "value": 25123,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "jwalker2276",
      },
    },
    {
      "score": {
        "value": 25122,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player56",
      },
    },
    {
      "score": {
        "value": 25121,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player34",
      },
    },
    {
      "score": {
        "value": 25120,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player134",
      },
    },
    {
      "score": {
        "value": 24000,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player10",
      },
    },
    {
      "score": {
        "value": 24399,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player100",
      },
    },
    {
      "score": {
        "value": 24356,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player129",
      },
    },
    {
      "score": {
        "value": 24325,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player1",
      },
    },
    {
      "score": {
        "value": 24123,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player145",
      },
    },
    {
      "score": {
        "value": 24122,
        "recordDate": "2022-12-12T16:38:18.993842-06:00"
      },
      "player": {
        "publicName": "player12",
      },
    },
  ],
  "message": "Successfully returned scores."
}



