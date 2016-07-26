interface IChuckNorrisJoke {
    
    type: string,

    value: string
}

function showChuckAlert(joke:IChuckNorrisJoke) {
    alert("Type: " + joke.type + "\nJoke: " + joke.value);
}