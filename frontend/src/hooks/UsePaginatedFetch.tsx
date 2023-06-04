import axios from "axios";
import { useState, useEffect } from "react";
import { Filter } from "../components/reusable/pagination/Filter";
import { PaginatedResult } from "../components/reusable/pagination/PaginatedResult";

const usePaginatedFetch = <T,>(url: string, pageIndex: number,
    pageSize: number,
    filters: Filter[], sortColumn: string = "Id",
    updateNeeded: boolean = false) => {
    const [data, setData] = useState<PaginatedResult<T>>({
        pageIndex: 0,
        pageSize: 0, total: 0, items: []
    });
    const client = axios.create({
        baseURL: url
    });

    useEffect(() => {
        client
            .post('', {
                pageIndex: pageIndex,
                pageSize: pageSize,
                columnNameForSorting: sortColumn,
                sortDirection: "ASC",
                requestFilters: {
                    logicalOperators: 1,
                    filters: filters
                }
            })
            .then((response) => setData(response.data));
    }, [pageIndex, filters, updateNeeded]);

    return data;
};

export default usePaginatedFetch;