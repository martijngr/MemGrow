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

const getSeedById = async function(seedId){
    try {
        const response = await axios.get(`${API}Seed/${seedId}`);
        return response.data;
    } catch (error) {
        console.error(error);
        alert('An error occured from the api while getting the seed by id');
        return [];
    }
}

const editSeed = async function(seed){
    try {
        const response = await axios.put(`${API}Seed`, seed);
        return response.data;
    } catch (error) {
        console.error(error);
        alert('An error occured from the api while deleting the seed');
        return [];
    }
}

const deleteSeed = async function(seedId){
    try {
        const response = await axios.delete(`${API}Seed/${seedId}`);
        return response.data;
    } catch (error) {
        console.error(error);
        alert('An error occured from the api while deleting the seed');
        return [];
    }
}
const searchSeed = async function(keyword){
    try {
        const response = await axios.get(`${API}Seed/search/${keyword}`);
        return response.data;
    } catch (error) {
        console.error(error);
        alert('An error occured from the api while searching for seeds');
        return [];
    }
}

export const SeedService = {
    saveSeed, 
    getSeeds,
    deleteSeed,
    getSeedById,
    editSeed,
    searchSeed
};