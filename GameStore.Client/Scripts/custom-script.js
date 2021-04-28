function setGenres(event) {
    //location = `/Games/Index?filters=Genre&name=${event.target.value}`
    $("#games").load(`/Games/Filter?filter=Genre&name=${encodeURIComponent(event.target.value)}`);
}

function setDevelopers(event) {
    $("#games").load(`/Games/Filter?filter=Developer&name=${encodeURIComponent(event.target.value)}`);
}

function findGamebyName() {
   let name = document.querySelector("#input-name-search").value;
    $("#games").load(`/Games/Search?name=${name}`);
}

function sort(event) {
    $("#games").load(`/Games/Sort?type=${encodeURIComponent(event.target.value)}`);
}
