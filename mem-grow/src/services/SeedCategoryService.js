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

export const SeedCategoryService = {
    getSeedCategories
};