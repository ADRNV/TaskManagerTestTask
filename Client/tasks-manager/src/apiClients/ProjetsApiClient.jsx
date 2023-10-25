import axios from "axios";

export default class ProjectsClient{

    async getProjects(page, size){
        
        const instance = axios.create({
            baseURL: "https://localhost:44379/api/Projects",
            timeout: 1000,
        })
        var data = await instance.get("page",{params:{page:page, size:size}})
       
        return data.data
    }

}