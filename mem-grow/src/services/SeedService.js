import * as axios from 'axios';
import { API } from '../config';

const saveSeed = async function (viewModel) {
    try {
        var postData = {
            description: viewModel.seed,
            categoryId: viewModel.selectedCategory
        };
        const response = await axios.post(`${API}Seed`, postData);
        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }
};

const getSeeds = async function(){
    try {
        const response = await axios.get(`${API}Seed`);
        return response.data;
    } catch (error) {
        console.error(error);
        alert('An error occured while fetching the seeds from the API');
        return [];
    }
}

export const SeedService = {
    saveSeed, 
    getSeeds
};