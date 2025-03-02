// @ts-ignore
import {photo} from './photo';


export interface member {
    id: number
    username: string
    photoUrl: string
    age: number
    knownAs: string
    created: Date
    lastActivity: Date
    gender: string
    introduction: string
    interests: string
    lookingFor: string
    city: string
    country: string
    photos: photo[]
}
