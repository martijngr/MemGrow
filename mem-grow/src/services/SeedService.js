import * as axios from 'axios';
import { API } from '../config';

const saveSeed = async function (viewModel) {
    console.log("saving viewmodel", viewModel);
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

export const SeedService = {
    saveSeed
};