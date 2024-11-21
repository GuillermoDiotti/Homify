export interface APIError {
  error: {
		innerCode: string;
		message: string;
	};
  ok: boolean;
  statusText: string;
  status: string;
}