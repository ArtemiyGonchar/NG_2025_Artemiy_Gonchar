export function setupCounter(element) {
  let savedData = localStorage.getItem('Results');
  let epic = JSON.parse(savedData);
  console.log(epic.wrong);
  console.log(epic);
  /*let counter = 0
  const setCounter = (count) => {
    counter = count
    element.innerHTML = `count is ${counter}`
  }*/
  element.innerHTML = `Answers: Correct: ${epic.correct}, Wrong: ${epic.wrong}, skipped: ${epic.skipped}`
  //element.addEventListener('click', () => setCounter(counter + 1))
  //setCounter(0)
}
