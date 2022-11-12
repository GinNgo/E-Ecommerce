import { Box, Grid, Button, IconButton, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import CheckOutlinedIcon from "@mui/icons-material/CheckOutlined";
// import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";
// import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";
import Header from "../../Components/Header";
import { useEffect, useState } from "react";
import Categories from "../../Services/Category/CategoriesApi";
import CreateOutlinedIcon from "@mui/icons-material/CreateOutlined";
import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";
import AddCircleOutlineOutlinedIcon from "@mui/icons-material/AddCircleOutlineOutlined";
import { Link } from "react-router-dom";

const Category = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const checkSelection = () => {
    Categories.PutTrash(selectedRows);
    window.location.reload();
  };

  const columns = [
    { field: "categoryId", headerName: "ID" },
    {
      field: "categoryName",
      headerName: "CategoryName",
      flex: 1,

      cellClassName: "name-column--cell",
    },

    {
      field: "createBy",
      headerName: "CreateBy",
    },
    {
      field: "Status",
      headerName: "Status",

      renderCell: ({ row: { status } }) => {
        return status === true ? (
          <CheckOutlinedIcon className="ckeck-colum--cell" />
        ) : (
          <CloseOutlinedIcon className="no-ckeck-colum--cell" />
        );
      },
    },

    {
      field: "isDeleted",
      headerName: "IsDeleted",
      cellClassName: "MuiDataGrid-cell--textCenter",

      renderCell: ({ row: { isDeleted } }) => {
        return isDeleted === true ? (
          <CheckOutlinedIcon className="ckeck-colum--cell" />
        ) : (
          <CloseOutlinedIcon className="no-ckeck-colum--cell" />
        );
      },
    },
    {
      field: "action",
      headerName: "Action",

      renderCell: ({ row: { categoryId } }) => {
        return (
          <Grid>
            <Link to={`/category/update/${categoryId}`}>
              <IconButton>
                <CreateOutlinedIcon className="create-colum--cell" />
              </IconButton>
            </Link>
          </Grid>
        );
      },
    },
  ];
  const [responseData, setResponseData] = useState([]);
  const [pageSize, setPageSize] = useState(10);
  const [page, setPage] = useState(0);
  const [selectedRows, setSelectedRows] = useState([]);
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const resp = await Categories.GetCategories();
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Box m="20px">
      <Box sx={{ display: "flex", alignItems: "center" }}>
        <Header title="CATEGORY" subtitle="Managing the Catalog" />{" "}
        <Link to={`/category/create`} style={{ listStyleType: "none" }}>
          <Button color="secondary" variant="contained">
            <AddCircleOutlineOutlinedIcon />
            CREATE CATEGORY
          </Button>
        </Link>
        <Link to={`/category/delete`} style={{ listStyleType: "none" }}>
          <Button color="secondary" variant="contained">
            <DeleteOutlinedIcon />
            GO TO CATEGORY TRASH
          </Button>
        </Link>
        <Button color="secondary" variant="contained" onClick={checkSelection}>
          <DeleteOutlinedIcon />
          DElELE CATEGORY
        </Button>
      </Box>
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
          "& .ckeck-colum--cell": {
            color: colors.greenAccent[600],
          },
          "& .no-ckeck-colum--cell": {
            color: colors.redAccent[500],
          },
          "& .create-colum--cell": {
            color: colors.blueAccent[700],
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
          "& .MuiDataGrid-columnHeaderTitle": {},
        }}
      >
        <DataGrid
          checkboxSelection
          rows={responseData}
          style={{ fontSize: 14 }}
          columns={columns}
          loading={responseData.length === 0}
          getRowId={(row) => row.categoryId}
          page={page}
          pageSize={pageSize}
          onPageChange={(newPage) => setPage(newPage)}
          onPageSizeChange={(newPageSize) => setPageSize(newPageSize)}
          rowsPerPageOptions={[5, 10, 20]}
          pagination
          onSelectionModelChange={(ids) => {
            const selectedIDs = ids;
            console.log(selectedIDs);
            setSelectedRows(selectedIDs);
          }}
          {...responseData}
        />
      </Box>
    </Box>
  );
};

export default Category;
