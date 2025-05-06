export function answersLocalStorage(answer){
    let results = {correct: 0, wrong: 0, skipped: 0};
    let savedData = localStorage.getItem('Results');

    if (savedData){
        results = JSON.parse(savedData);
    }

    if(answer == "true"){
        results.correct += 1;
    } 
    if(answer == "false"){
        results.wrong += 1;
    }
    if(answer == "skipped"){
        results.skipped += 1;
    }

    localStorage.setItem('Results', JSON.stringify(results));
}

export function changeDifficulty(answer){
    let results = "easy";
    let savedData = localStorage.getItem('Difficulty');
    if (savedData){
        results = JSON.parse(savedData);
    }

    if (answer == "easy"){
        results = answer 
    }
    if (answer == "normal"){
        results = answer 
    }
    if (answer == "hard"){
        results = answer 
    }

    localStorage.setItem('Difficulty', JSON.stringify(results));
}