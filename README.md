# Score Board

## Overview

This api allows recording of a user's score for a specific game. In order for this to occur a few operation must happen before a score can be record.

1. Create Game that scores and players can be associated with.
2. After score is generated from game, user can create a display name.
3. Once a player and score are setup, a request can be made to record it with the service.

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

### Player name check

Check if requested player name is available.

Request
```json
{
  "name": "jwalker2276"
}
```

Resposne
```json
{
  "data": {
    "isNameAvailable": true, // or false
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
    "score": 25123,
    "player": {
      "requestedName": "jwalker2276",
      "publicName": "player123",
      "nameReviewState": "underReview"
    },
  },
  "message": "Successfully created score."
}
```

### List scores

List top ten scores of all time.

Request
```json
{
  "gameId": "99852beb-6fe3-4927-86b1-ec736e754795"
}
```

Response
```json
{
  "data": [
    {
      "score": 25123,
      "player": {
        "publicName": "jwalker2276",
      },
    },
    {
      "score": 25122,
      "player": {
        "publicName": "player56",
      },
    },
    {
      "score": 25121,
      "player": {
        "publicName": "player34",
      },
    },
    {
      "score": 25120,
      "player": {
        "publicName": "player134",
      },
    },
    {
      "score": 24000,
      "player": {
        "publicName": "player10",
      },
    },
    {
      "score": 24399,
      "player": {
        "publicName": "player100",
      },
    },
    {
      "score": 24356,
      "player": {
        "publicName": "player129",
      },
    },
    {
      "score": 24325,
      "player": {
        "publicName": "player1",
      },
    },
    {
      "score": 24123,
      "player": {
        "publicName": "player145",
      },
    },
    {
      "score": 24122,
      "player": {
        "publicName": "player12",
      },
    },
  ],
  "message": "Successfully returned scores."
}



