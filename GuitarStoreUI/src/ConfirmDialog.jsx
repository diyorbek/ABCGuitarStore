import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
} from '@mui/material';

export function ConfirmDialog({ open, title, textContent, actions }) {
  return (
    <>
      <Dialog open={open} maxWidth="sm">
        <DialogTitle id="alert-dialog-title" fontWeight="bold">
          {title}
        </DialogTitle>
        <DialogContent>{textContent}</DialogContent>
        <DialogActions>{actions}</DialogActions>
      </Dialog>
    </>
  );
}
