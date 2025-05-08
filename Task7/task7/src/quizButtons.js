import { getCharacter } from 'rickmortyapi'
export async function quizButtons(characterId){
    let difficulty = localStorage.getItem('Difficulty');
    if (difficulty == null){
        difficulty = "easy";
    }
    difficulty = difficulty.replaceAll('"', '');


    let divContainer = document.createElement('div');
    divContainer.className = "card";
    
    let charMain = await getCharacter(characterId);
    let charRandom;
    let number = Math.floor(Math.random() * 4);

    for(let i = 0; i < 4; i++){
        let button = document.createElement("button");
        //button.className = 'card';
        button.textContent = "epic";
        if(i == number){
            if (difficulty == "easy"){
                button.textContent = charMain.data.name;
            }
            if (difficulty === "normal"){
                button.textContent = charMain.data.location.name;
            }
            if (difficulty === "hard"){
                let episode = charMain.data.episode[0].split('/').pop();
                button.textContent = `Episode: ${episode}`;
            }
            button.dataset.answer = "true";
        } else{
            charRandom = await getCharacter((Math.floor(Math.random() * 826)));
            //button.textContent = charRandom.data.name;
            if (difficulty == "easy"){
                button.textContent = charRandom.data.name;
            }
            if (difficulty === "normal"){
                button.textContent = charRandom.data.location.name;
            }
            if (difficulty === "hard"){
                let episode = charRandom.data.episode[0].split('/').pop()
                button.textContent = `Episode: ${episode}`;
            }
            button.dataset.answer = "false";
        }

        divContainer.appendChild(button);
    }

    return divContainer;
}