export function setupCounter(element) {
  let savedData = localStorage.getItem('Results');
  let parsedData = JSON.parse(savedData);
  if (!parsedData) {
    parsedData = { correct: 0, wrong: 0, skipped: 0 };
  }
  //console.log(parsedData.wrong);
  //console.log(parsedData);
  /*let counter = 0
  const setCounter = (count) => {
    counter = count
    element.innerHTML = `count is ${counter}`
  }*/
  element.innerHTML = `Answers: Correct: ${parsedData.correct}, Wrong: ${parsedData.wrong}, skipped: ${parsedData.skipped}`
  //element.addEventListener('click', () => setCounter(counter + 1))
  //setCounter(0)
}
