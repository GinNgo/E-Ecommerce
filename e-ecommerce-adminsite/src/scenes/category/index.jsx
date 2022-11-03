import { Box, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import CheckOutlinedIcon from "@mui/icons-material/CheckOutlined";
// import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";
// import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";
import Header from "../../Components/Header";
import { useEffect, useState } from "react";
import Categories from "../../Services/Category/CategoriesApi";

const Category = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const columns = [
    { field: "categoryId", headerName: "ID", flex: 0.5 },
    {
      field: "categoryName",
      headerName: "CategoryName",
      flex: 1,
      cellClassName: "name-column--cell",
    },
    {
      field: "parentName",
      headerName: "ParentName",
      flex: 1,
    },
    {
      field: "createBy",
      headerName: "CreateBy",
    },
    {
      field: "Status",
      headerName: "Status",
      flex: 1,
      justifyContent: "center",

      renderCell: ({ row: { status } }) => {
        return status === true ? <CheckOutlinedIcon /> : <CloseOutlinedIcon />;
      },
    },

    {
      field: "isDeleted",
      headerName: "IsDeleted",
      flex: 1,
      justifyContent: "center",
      renderCell: ({ row: { isDeleted } }) => {
        return isDeleted === true ? (
          <CheckOutlinedIcon />
        ) : (
          <CloseOutlinedIcon />
        );
      },
    },
  ];
  const [responseData, setResponseData] = useState([]);
  const [pageSize, setPageSize] = useState(10);
  const [page, setPage] = useState(0);

  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const resp = await Categories.GetCategories();
      console.log(resp.data);
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Box m="20px">
      <Header title="CATEGORY" subtitle="Managing the Catalog" />
      <Box
        m="40px 0 0 0"
        height="75vh"
        sx={{
          "& .MuiDataGrid-root": {
            border: "none",
          },
          "& .MuiDataGrid-cell": {
            borderBottom: "none",
          },
          "& .name-column--cell": {
            color: colors.greenAccent[300],
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            borderBottom: "none",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            borderTop: "none",
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiCheckbox-root": {
            color: `${colors.greenAccent[200]} !important`,
          },
          "& .MuiDataGrid-cell--textCenter": {
            justifyContent: "center",
          },
        }}
      >
        <DataGrid
          checkboxSelection
          rows={responseData}
          columns={columns}
          loading={responseData.length === 0}
          getRowId={(row) => row.categoryId}
          page={page}
          pageSize={pageSize}
          onPageChange={(newPage) => setPage(newPage)}
          onPageSizeChange={(newPageSize) => setPageSize(newPageSize)}
          rowsPerPageOptions={[5, 10, 20]}
          pagination
          {...responseData}
        />
      </Box>
    </Box>
  );
};

export default Category;
