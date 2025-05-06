import { getCharacter } from 'rickmortyapi'
export async function setupImage(element, characterId){
    let char = await getCharacter(characterId);
    let ImageURL = await char.data.image;
    element.src = ImageURL;
}