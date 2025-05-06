import './style.css'
import { setupImage } from './changeImage.js'
import { randomMainChar } from './randomMainCharacter.js'
import { quizButtons } from './quizButtons.js'
import * as storage from './localStorage.js'
import { setupCounter } from './counter.js'

document.querySelector('#app').innerHTML = `
  <div>
      <div class="difficulty">
        <button id="easy">Easy</button>
        <button id="normal">Normal</button>
        <button id="hard">Hard</button>
        <br> <br>
        <button id="skip">Skip</button>
      </div>
        <p id="counter">counter:</p>
      <img id="char-image" src="" class="logo" alt="JavaScript logo" />

  </div>
`
let mainCharacter = randomMainChar()
setupCounter(document.querySelector("#counter"));
setupImage(document.querySelector("#char-image"), mainCharacter)
let quizbuttons = await quizButtons(mainCharacter);

document.querySelector('#app').appendChild(quizbuttons);
/*
document.querySelector('.card').onclick = async (event) => {
  if (event.target.tagName === 'BUTTON') {
    let answer = event.target.dataset.answer;
    console.log(answer);
    storage.answersLocalStorage(answer);
    
  }
}*/

document.querySelector('#app').addEventListener('click', async (event) => {
  if (event.target.tagName === 'BUTTON' && event.target.closest('.card')) {
    let answer = event.target.dataset.answer;
    console.log(answer);
    storage.answersLocalStorage(answer);

    mainCharacter = randomMainChar();
    setupCounter(document.querySelector("#counter"));
    setupImage(document.querySelector("#char-image"), mainCharacter);
    document.querySelector('#app').removeChild(quizbuttons);
    quizbuttons = await quizButtons(mainCharacter);
    document.querySelector('#app').appendChild(quizbuttons);
  }
});



document.querySelector('.difficulty').onclick = async (event) => {
  const buttonId = event.target.id;

  if (buttonId == "easy" || buttonId == "normal" || buttonId == "hard") {
    storage.changeDifficulty(buttonId);
  } else if (buttonId == "skip") {
    storage.answersLocalStorage("skipped");
  }
    mainCharacter = randomMainChar();
    setupCounter(document.querySelector("#counter"));
    setupImage(document.querySelector("#char-image"), mainCharacter);
    document.querySelector('#app').removeChild(quizbuttons);
    quizbuttons = await quizButtons(mainCharacter);
    document.querySelector('#app').appendChild(quizbuttons);
};

/*
document.querySelector('#easy').onclick = () => {
  storage.changeDifficulty("easy")
}

document.querySelector('#normal').onclick = () => {
  storage.changeDifficulty("normal")
}

document.querySelector('#hard').onclick = () => {
  storage.changeDifficulty("hard")
  
}

document.querySelector('#skip').onclick = async () => {
  storage.answersLocalStorage("skipped");
  mainCharacter = randomMainChar();
  setupCounter(document.querySelector("#counter"));
  setupImage(document.querySelector("#char-image"), mainCharacter);
  document.querySelector('#app').removeChild(quizbuttons);
  quizbuttons = await quizButtons(mainCharacter);
  document.querySelector('#app').appendChild(quizbuttons);
}*/