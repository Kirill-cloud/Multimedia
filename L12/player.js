
var video = document.getElementsByTagName('video');
var playbackSRate = 1;

function playClick() {

    document.getElementById('endTime').textContent = timeFormat(video[0].duration);

    var x = document.getElementById('playButton');
    if (video[0].paused) {
        video[0].play();
        x.textContent = "⏸︎"
    } else {
        video[0].pause();
        x.textContent = "▶"
    }
}
function stop() {
    video[0].pause();
    video[0].currentTime = 0;
    var x = document.getElementById('playButton');
    x.textContent = "▶"
}
function rewind(event) {
    var bounds = event.target.getBoundingClientRect();
    var x = event.clientX - bounds.left;
    video[0].currentTime = x / 600 * video[0].duration;
}
function speedUp() {
    video[0].playbackRate += .25;
    updateSpeed();
}
function speedDown() {
    if (video[0].playbackRate > 0.25) {
        video[0].playbackRate -= .25;
        updateSpeed();
    }
}
function speedNormalize() {
    video[0].playbackRate = 1;
    updateSpeed();
}
function updateSpeed() {
    var speedLabel = document.getElementById('timer');
    speedLabel.textContent = video[0].playbackRate;
}
function tick() {
    var progressbarStyle = document.getElementById('progress').style;
    var timer = document.getElementById('timeElapsed');

    var maxWidth = 600;

    progressbarStyle.width = video[0].currentTime / video[0].duration * maxWidth + "px";
    timer.textContent = timeFormat(video[0].currentTime);


}
function timeFormat(timeInSeconds) {
    var hours = 0;
    var minutes = 0;
    var seconds = 0;

    hours = Math.floor(timeInSeconds / 3600);
    timeInSeconds %= 3600;

    minutes = Math.floor(timeInSeconds / 60)
    timeInSeconds %= 60;

    seconds = Math.floor(timeInSeconds);

    return timeNormalize(hours) + ":" + timeNormalize(minutes) + ":" + timeNormalize(seconds);
}
function timeNormalize(timeEv) {
    if (timeEv < 10) {
        return "0" + timeEv;
    }
    return timeEv;
}