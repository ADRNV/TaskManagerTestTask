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

    async getAmountTime(start, cancel){
        
        let config = {
            method: 'get',
            maxBodyLength: Infinity,
            url: 'https://localhost:44379/api/Task/calc',
            headers: { },
            params:{start:start, cancelDate:cancel}
          };
          
        const instance = axios.create(config)

        return (await axios.request(config)).data
    }

}