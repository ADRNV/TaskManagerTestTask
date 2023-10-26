import { useState } from "react"

export const useFetchHook = (callback) => {

    var [loading, setLoading] = useState(true)

    var [error, setError] = useState(null) 

    const fetching = async () => {
        try{
            await callback()
            setLoading(false)
        }
        catch(e){
            setError(e)
            setLoading(false)
        }
    }

    return [fetching, loading, error]
}