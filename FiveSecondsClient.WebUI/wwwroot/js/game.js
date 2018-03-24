var tim;
var seconds = 5;
var players = [];
var i = 1;
var currnetPlayerId = 1;
var maxPalyerId = 1;
var isNotDone = true;
document.getElementById('currentUser').innerHTML = document.getElementById('player-1').innerHTML;
do {
    var name = document.getElementById('player-' + i).innerHTML;
    var score = parseInt(document.getElementById('score-' + i).innerHTML);

    if (!name) {
        isNotDone = false;
    } else {
        players.push({ 'id': i, 'name': name, 'score': score });
        i++;
        maxPalyerId++;
    }
} while (isNotDone);
i = i - 1;
maxPalyerId = maxPalyerId - 1;


function countdown() {
    if (parseInt(seconds) > 0) {
        seconds = parseInt(seconds) - 1;
        document.getElementById("timer").innerHTML = seconds;
        tim = setTimeout("countdown()", 1000);

    }

    if (seconds === 0) {
        $('#modal2').modal('open');
        seconds = 5;
        document.getElementById("timer").innerHTML = seconds;
        clearTimeout(tim);
    }
}


function goodAnswered() {
    var currentPlayer = players.find(x => x.id === currnetPlayerId);
    currentPlayer.score++;
    document.getElementById('score-' + currnetPlayerId).innerHTML = (currentPlayer.score);
    refreshState();
    checkWin(currentPlayer.score, currentPlayer.name);
}


function badAnswered() {
    refreshState();
}

function checkWin(score, name) {
    if (score >= 2) {
        $('#modal2').modal('close');
        document.getElementById('winner').innerHTML = name;
        $('#modal3').modal('open');
    }
}

function refreshState() {
    if (currnetPlayerId !== (maxPalyerId - 1)) {
        currnetPlayerId += 1;
    } else {
        currnetPlayerId = 1;
    }
    document.getElementById('currentUser').innerHTML = players.find(x => x.id === currnetPlayerId).name;
}