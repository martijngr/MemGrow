import * as axios from 'axios';
import { API } from '../config';

const getSeedCategories = async function () {
    try {
        const response = await axios.get(`${API}SeedCategory`);
        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }
};

const addSeedCategory = async function(newSeedCategoryName){
    try {
        const payload = {
            name: newSeedCategoryName
        };
        const response = await axios.post(`${API}SeedCategory`, payload);
        return response.data;
    } catch (error) {
        console.error(error);
    }
}

export const SeedCategoryService = {
    getSeedCategories,
    addSeedCategory
};