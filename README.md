# Score Board

## Overview

This application provides a web api to setup and record user scores, then display them with scoreboards defined by their settings.

1. `POST` to the game endpoint to setup a new game.
1. `POST` to the player endpoint to see if desired player name is free and allowed to be used.
1. `POST` to the scores endpoint to save a score for a new or existing player.
1. `POST` to the scoreboard endpoint to setup a new scoreboard for display.
1. `GET` to the scoreboard with an id to display that scoreboard.

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
    "isNameApproved": true
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
  "createdBy": "Web Api"
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
      "publicName": "jwalker2276",
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
  "createBy": "Admin"
}
```

Response
```json
{
  "data": {
    "id": "785d5b4c-f517-4533-8151-58ef82e8786f",
    "gameId": "99852beb-6fe3-4927-86b1-ec736e754795",
    "name": "Top five scores of all time",
    "maxNumberOfScores": 5,
    "creationDate": "2022-12-29T18:33:43.5089082-06:00",
    "scores": []
  },
  "message": "Successfully created scoreboard."
}
```

### Display scoreboard

Request

`GET` /api/v1/scoreboards/785d5b4c-f517-4533-8151-58ef82e8786f

Response

```json
{
  "data": {
    "id": "785d5b4c-f517-4533-8151-58ef82e8786f",
    "gameId": "a1526573-05a1-429f-b432-3eae654c6873",
    "name": "Top five scores of all time",
    "maxNumberOfScores": 5,
    "creationDate": "2022-12-29T18:33:43.5089082-06:00",
    "scores": [
      {
        "score": {
          "value": 1000000,
          "recordDate": "2022-12-29T18:14:06.2155972-06:00"
        },
        "player": {
          "publicName": "Jay"
        }
      },
      {
        "score": {
          "value": 125534,
          "recordDate": "2022-12-29T18:15:16.0207499-06:00"
        },
        "player": {
          "publicName": "Jay25"
        }
      },
      {
        "score": {
          "value": 100000,
          "recordDate": "2022-12-29T18:14:19.0774629-06:00"
        },
        "player": {
          "publicName": "Jay30"
        }
      },
      {
        "score": {
          "value": 5000,
          "recordDate": "2022-12-29T18:15:04.0191932-06:00"
        },
        "player": {
          "publicName": "Jay25"
        }
      },
      {
        "score": {
          "value": 1234,
          "recordDate": "2022-12-29T18:15:08.6673903-06:00"
        },
        "player": {
          "publicName": "Jay25"
        }
      }
    ]
  },
  "message": "Successfully found scoreboard."
}
```



